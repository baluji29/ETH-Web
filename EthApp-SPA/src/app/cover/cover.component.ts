import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-cover',
  templateUrl: './cover.component.html',
  styleUrls: ['./cover.component.css']
})
export class CoverComponent implements OnInit {
  model: any = {};

  constructor(private authServices: AuthService) { }
  public isMenuCollapsed = true;

  ngOnInit() {
  }
  login() {
    this.authServices.login(this.model).subscribe(next => {
      console.log('Logged in Successfully');
    }, error => {
      console.log('login Failed');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('User logged out');
  }
}
