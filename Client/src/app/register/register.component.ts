import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder
} from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { User } from '../_models/user';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;
  user: User;
  model: any = {};

  constructor(
    private authService: AuthService,
    private alertify: AlertifyService,
    private router: Router,
    private fb: FormBuilder
  ) {}

  ngOnInit() {
    this.bsConfig = {
      containerClass: 'theme-red',
      maxDate: new Date(new Date().setFullYear(new Date().getFullYear() - 18))
    };
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.fb.group(
      {
        gender: ['male'],
        username: ['', Validators.required],
        knownAs: ['', Validators.required],
        dateOfBirth: [null, Validators.required],
        city: ['', Validators.required],
        country: ['', Validators.required],
        password: [
          '',
          [
            Validators.required,
            Validators.minLength(4),
            Validators.maxLength(8)
          ]
        ],
        confirmPassword: ['', [Validators.required]]
      },
      { validator: this.passwordMatchValidator }
    );
  }

  register() {
    if (!this.registerForm.valid) {
      return;
    }

    this.user = Object.assign({}, this.registerForm.value);

    this.authService.register(this.user).subscribe(
      () => {
        this.alertify.success('Registration Successful');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.authService.login(this.user).subscribe(() => {
          this.router.navigate(['/members']);
        });
      }
    );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }

  passwordMatchValidator(form: FormControl) {
    return form.get('password').value === form.get('confirmPassword').value
      ? null
      : { mismatch: true };
  }
}
