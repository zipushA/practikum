import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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
}
