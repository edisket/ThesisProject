import { Component } from "@angular/core";
import { FormControl, FormGroup } from '@angular/forms'
import { Router } from "@angular/router";
import { AuthenticateAccountMessage } from "../dto/AuthenticateAccountMessage";
import { AuthService } from "../services/auth.service";
import { TransactionService } from "../services/transaction.service";
@Component({
    selector:'login-comp',
    templateUrl:'./login.component.html',
    styleUrls:['./login.component.css']
})
export class LoginComponent{



    constructor(
        private tranService:TransactionService,
        private router: Router
    ){}

    formGroup = new FormGroup({
        username:new FormControl(),
        password:new FormControl()
    })



    GetControl(formName:string):FormControl{

        return <FormControl> this.formGroup.controls[formName];


    }

    OnLogin(){


        if(this.formGroup.valid){
            var msg:AuthenticateAccountMessage = {
                requestMessage:{
                    username:this.GetControl('username').value,
                    password:this.GetControl('password').value
                },
                responseMessage:{}
            }


            this.tranService.RunTransaction('AuthAccount', msg).subscribe(res=>{



                msg.responseMessage = res;


                console.log(msg.responseMessage);


                if(msg.responseMessage.isValid){

                    this.router.navigate(['/dashboard'])

                    AuthService.isLoggedIn = true;

                }else{

                }


            })


            
        }else{

            if(this.GetControl('username').value == undefined)
                console.log("Empty username");
            
            if(this.GetControl('password').value == undefined)
                console.log('Empty Password');

        }

      
    }
}