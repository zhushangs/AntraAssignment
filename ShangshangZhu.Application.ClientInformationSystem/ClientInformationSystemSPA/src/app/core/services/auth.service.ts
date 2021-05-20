import { User } from './../../shared/models/User';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable, BehaviorSubject } from 'rxjs';
import { Login } from './../../shared/models/login';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  //can be used only inside this class to push data
  private currentUserSubject = new BehaviorSubject<User>({} as User)

  //public here so that any component can subscribe to this subject and get data
  public currentUser = this.currentUserSubject.asObservable();

  //
  private isAuthSubject = new BehaviorSubject<boolean>(false);
  // use this subject to check whether user is authticated so that if true hide login/register buttons in the header
  public isAuth = this.isAuthSubject.asObservable();

  private user!: User;
  constructor(private apiService: ApiService) { }

  //take user/password from login component and post it to API service that will post to API
  login(userLogin: Login): Observable<boolean>{
    return this.apiService.create('account/login', userLogin).pipe(
      map(response=>{
        if(response){
          //save it to local storage
          localStorage.setItem('token', response.token);
          this.populateUserInfo();
          return true;
        }
        return false;
      })
    );
  }

  populateUserInfo(){
    //get the token from the localstorage and decode it and get the user info such as email, name to show in the header
    var token = localStorage.getItem('token');
    if(token){
      //decode token
      var decodedToken = new JwtHelperService().decodeToken(token);
      this.user = decodedToken;
      this.currentUserSubject.next(this.user);
      this.isAuthSubject.next(true);
    }
  }

  logout(){
    //remove the token from localstorage
    localStorage.removeItem('token');
    this.currentUserSubject.next({} as User);
    this.isAuthSubject.next(false);
  }
}
