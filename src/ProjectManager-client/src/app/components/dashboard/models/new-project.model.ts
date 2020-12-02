import { Person } from './person.model';
import { ProjectTask } from './project-task.model';

export interface NewProject {
    projectTitle: string,
    startDate: Date,
    endDate: Date,
    description: string,
    tasks: ProjectTask[],
    attendants: Person[]
}