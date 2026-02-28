import { Routes } from '@angular/router';
import { ProductCatalogComponent } from './components/product-catalog/product-catalog.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';

export const routes: Routes = [
    { path: '', component: ProductCatalogComponent },
    { path: 'product/:id', component: ProductDetailsComponent },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    { path: 'admin', component: AdminDashboardComponent },
    { path: '**', redirectTo: '' }
];
