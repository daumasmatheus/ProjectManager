import { Person } from './person.model';

export class ProjectTask {
    constructor(_id: number) {
        this.id = _id;
    }

    id: number;
    title: string;
    priority: number;
    conclusionDate: Date;
    description: string;
    attendant: Person;
    isConcluded: boolean;
}