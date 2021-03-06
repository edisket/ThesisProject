import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "../services/auth.service";


@Component({
    selector:'dashboard',
    templateUrl:'./dashboard.component.html',
    styleUrls:['./dashboard.component.css']
})
export class DashboardComponent{


    constructor(
        private router: Router
    ){}


    OnLogOut(){

        this.router.navigate(['']);
        AuthService.isLoggedIn = false;

    }
}