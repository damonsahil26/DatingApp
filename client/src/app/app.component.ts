import { HttpClient } from '@angular/common/http';
import { error } from '@angular/compiler/src/util';
import { Component, OnInit } from '@angular/core';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'The Dating App';
  users: any;

  //Dependency Injection
  constructor(private http: HttpClient, private AccountService:AccountService) {

  }
    ngOnInit(): void {
      this.getUsers();
      this.setCurrentUser();
    }


    setCurrentUser(){
      const user:User=JSON.parse(localStorage.getItem('user'));
      this.AccountService.setCurrentUser(user);
    }
  //Http Request

  getUsers():void  {

    this.http.get('https://localhost:5001/api/users').subscribe(
      response => {this.users = response},
      error => {
        console.log(error);
      }
    )
  }




}
