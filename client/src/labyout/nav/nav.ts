import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from "@angular/router";
import { ToastService } from '../../core/services/toast-service';
import { HasRole } from '../../shared/directives/has-role';
import { BusyService } from '../../core/services/busy-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive, HasRole],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})
export class Nav {
  protected accountService = inject(AccountService);
  protected busyService = inject(BusyService);
  private router = inject(Router);
  private toast = inject(ToastService);
  protected creds: any = {};
  protected loading = signal(false);

  login() {
    this.loading.set(true);
    this.accountService.login(this.creds).subscribe({
      next: () => {
        this.router.navigateByUrl('/members'),
        this.toast.success('Logged in successfully');
        this.creds = {};
      },
      error: error => {
        console.log(error);
        this.toast.error(error.error);
      },
      complete: () => this.loading.set(false)
    });
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
