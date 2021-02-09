// import { Injectable } from "@angular/core";
// import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
// import { Observable } from "rxjs";
// import { Message } from "../_models/message";
// import { MessageService } from "../_services/message.service";

// @Injectable()
// export class MessageResolverService implements Resolve<Message> {
//     constructor(private messageService: MessageService) {}

//     resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Message> {
//         return this.messageService.getMessages();
//     }
// }