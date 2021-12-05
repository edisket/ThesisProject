import { Injectable } from "@angular/core";

@Injectable({
    providedIn:'root'
})
export class AuthService{



    public static isLoggedIn:boolean = false;

    constructor(){}
}