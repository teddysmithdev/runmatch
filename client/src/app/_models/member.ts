import { Photo } from "./photo";

export interface Member {
    id: number;
    userName: string;
    photoUrl?: any;
    age: Date;
    dateOfBirth: Date;
    created: Date;
    lastActive: Date;
    gender?: any;
    introduction?: any;
    pace: number;
    mileage: number;
    city?: any;
    state?: any;
    photos: Photo[];
  }