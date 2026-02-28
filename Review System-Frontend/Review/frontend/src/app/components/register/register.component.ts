import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrl: '../login/login.component.css'
})
export class RegisterComponent {
  name = '';
  email = '';
  password = '';
  errorMsg = '';
  loading = false;

  constructor(private auth: AuthService, private router: Router) { }

  register() {
    this.loading = true;
    this.errorMsg = '';
    this.auth.register({ name: this.name, email: this.email, password: this.password }).subscribe({
      next: () => {
        this.loading = false;
        alert('Registration successful! Please login.');
        this.router.navigate(['/login']);
      },
      error: (err) => {
        this.loading = false;
        this.errorMsg = 'Failed to register. Email may be taken or data invalid.';
      }
    });
  }
}
