import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { principal } from '../models/principal';
import { teacher } from '../models/teacher';


@Injectable({
  providedIn: 'root'
})
export class UsersService {
private baseUrl="https://localhost:7082/api/"
  constructor(private http :HttpClient) { }
  
  getAllTeacher(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}Teacher`);
}
getAllPrincipal(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}Pricipal`);
}
delete(id:number|undefined,user:string): Observable<any[]> {
  console.log(`${this.baseUrl}${user}/${id}`)
  return this.http.delete<any[]>(`${this.baseUrl}${user}/${id}`);
}
}
