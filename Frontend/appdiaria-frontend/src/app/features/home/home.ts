import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { PublicNavbar } from '../../layout/public-navbar/public-navbar';

@Component({
  selector: 'app-home',
  imports: [PublicNavbar, RouterLink],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {}
