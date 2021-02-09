export interface User {
    username: string;
    token: string;
    photoUrl: string;
    dateOfBirth: Date;
    city: string;
    state: string;
    gender: string;
    pace: number;
    mileage: number;
    runtime: number;
    roles: string[];
}