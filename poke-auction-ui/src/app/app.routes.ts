import { Routes } from '@angular/router';
import { AuctionsComponent } from './auctions/auctions.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  // Add your routes here, for example:
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'auctions', component: AuctionsComponent },
  // Add more routes as needed
];