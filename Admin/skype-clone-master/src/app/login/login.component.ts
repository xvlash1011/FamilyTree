import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppService } from '../app.service';
import { UserDataService } from '../core/user-data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  rootForm = this.fb.group({
    id: ['', Validators.compose([Validators.required, Validators.min(0)])],
  });

  constructor(
    private router: Router,
    private userData: UserDataService,
    private fb: FormBuilder,
    private appService: AppService
  ) {}

  ngOnInit(): void {}

  login() {
    const formData = this.rootForm.value;

    this.userData.get(+formData.id).subscribe(
      (data) => {
        this.appService.currentUser = data;
        this.router.navigateByUrl('/chat');
      },
      (err) => {
        alert('Đăng nhập thất bại');
      }
    );
  }
}
