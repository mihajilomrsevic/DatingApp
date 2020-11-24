import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from './_models/user';
import {AccountService} from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Dating App';
  users: any;

  constructor(private accountService: AccountService) {

  }
// ucitava se prilikom ucitavanja root stranice
  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    // iscitava iz localstorage trenutnog korisnika
    const user: User = JSON.parse(localStorage.getItem('user'));
    // smesta trenutnog korisnika u bafer
    this.accountService.setCurrentUser(user);
  }


}
