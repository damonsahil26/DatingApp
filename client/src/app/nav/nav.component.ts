import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  //Model object for storing Login form data.
  model:any={

  }
  constructor() { }

  ngOnInit(): void {
  }
  
  login(){
    console.log(this.model);
  }

}
