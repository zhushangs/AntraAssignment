import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  // HttpClient => used to communicate with API
  constructor(protected http: HttpClient) { }


  // getting array of json objects
  getList(path: string): Observable<any[]> {

    // var apiUrl = environment.apiUrl;
    // call only urls that get Json array from API
    return this.http.get(`${environment.apiUrl}${path}`)
      .pipe(
        map(resp => resp as any[])
      )

  }

  // get single json object movie/id
  getOne(path: string, id?: number): Observable<any> {

    return this.http.get(`${environment.apiUrl}${path}` + id).pipe(
      map(resp => resp as any)
    )

  }

  // post something
  create() {

  }

  // PUT
  update() {

  }

  // DELETE
  delete() {

  }

}
