import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  //HttpClient => used to communicate with API
  //private readonly == 
  constructor( protected http: HttpClient) { }
  
  // getting array of json objects
  getList(path: string): Observable<any[]>{

   // var apiUrl = environment.apiUrl;
   // call only urls that get json array from api
    return this.http.get(`${environment.apiUrl}${path}`).pipe(
      map(resp => resp as any[])
    )
  }

  //get single json object movie/id
  getOne(path: string, id?: number) {

    return this.http.get(`${environment.apiUrl}${path}`+ id).pipe(
      map(resp => resp as any)
    )

  }

  //post something
  create(){
  }

  //put
  update(){

  }

  //delete
  delete(){

  }
}
