import { Club } from "./club"
import { User } from "./user"

export class ClubParams {
    location: string = 'charlotte'
    pageNumber = 1;
    pageSize = 5;
    orderBy = 'lastActive';
    constructor(user: User) {
        this.location = user.city
    }
}