import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { BaseMessage } from "../dto/BaseMessage";
import { environment } from "src/environments/environment";
@Injectable(
    {
        providedIn:'root'
    }
)
export class TransactionService{


    constructor(
        private httpClient:HttpClient
    ){}


    private constructHttpHeader(){

        return new HttpHeaders({
            'Content-Type':'application/json'
        })
    }
    RunTransaction(tranCode:string, msg:BaseMessage){

        msg.tranCode = tranCode;
        let requestMsg = JSON.stringify(msg);
        requestMsg = JSON.stringify(requestMsg);

        console.log(requestMsg);
        return this.httpClient.post('http://localhost:9090/auth', requestMsg,{headers:this.constructHttpHeader()});


    }
}