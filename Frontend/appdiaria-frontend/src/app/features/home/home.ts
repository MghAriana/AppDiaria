import { Component } from '@angular/core';
import { PublicNavbar } from '../../layout/public-navbar/public-navbar';

@Component({
  selector: 'app-home',
  imports: [PublicNavbar],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {}
