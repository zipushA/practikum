import { Component } from '@angular/core';
import { teacher } from '../../models/teacher';
import { UsersService } from '../../services/users.service';
import { principal } from '../../models/principal';
import { MatButtonModule } from '@angular/material/button';
import { MatListModule } from '@angular/material/list'; 



@Component({
  selector: 'app-show-users',
  standalone: true,
  imports: [MatButtonModule,MatListModule],
  templateUrl: './show-users.component.html',
  styleUrl: './show-users.component.css'
})
export class ShowUsersComponent {
  teachers:teacher[] = [];
  principals:principal[]=[]
  constructor(private usersService:UsersService){}
 GetTeacher() {
    this.usersService.getAllTeacher().subscribe(
      (data) => {
    console.log(data)
        this.teachers = data; // שמירת המידע במערך
      },
      (error) => {
        console.error('Error fetching users', error); // טיפול בשגיאות
      }
    );
  }
  GetPrincipal(){
    this.usersService.getAllPrincipal().subscribe(
      (data) => {
    console.log(data)
        this.principals = data; // שמירת המידע במערך
      },
      (error) => {
        console.error('Error fetching users', error); // טיפול בשגיאות
      }
    );
  }
}
