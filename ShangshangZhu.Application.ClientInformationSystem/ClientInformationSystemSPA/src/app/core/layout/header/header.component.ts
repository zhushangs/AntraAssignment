import { User } from './../../../shared/models/User';
import { AuthService } from './../../services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent implements OnInit {

  isAuth!: boolean;
  user!: User;
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.authService.isAuth.subscribe((data) => {
      this.isAuth = data;
      console.log(this.isAuth);
    });

    this.authService.currentUser.subscribe((data) => {
      this.user = data;
      console.log(this.user);
    });
  }

  logout() {
    this.authService.logout();
    this.router.navigateByUrl('/login');
  }

}
