import { BaseMessage } from "./BaseMessage";

export interface AuthenticateAccountMessage extends BaseMessage{

    requestMessage:{
        username:string;
        password:string;
    }

    responseMessage:{
        isValid?:boolean;
    }

}