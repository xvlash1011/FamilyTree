import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppService } from '../app.service';
import { UserDataService } from '../core/user-data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  rootForm = this.fb.group({
    name: [
      '',
      Validators.compose([Validators.required, Validators.maxLength(255)]),
    ],
  });

  constructor(
    private router: Router,
    private userData: UserDataService,
    private fb: FormBuilder,
    private appService: AppService
  ) {}

  ngOnInit(): void {}

  register() {
    const formData = this.rootForm.value;

    this.userData.register(formData.name).subscribe(
      (registerData) => {
        this.appService.currentUser = {
          id: registerData.id,
          name: formData.name,
        };
        this.router.navigateByUrl('/chat');
      },
      (err) => {
        alert('Đăng ký thất bại');
      }
    );
  }
}
