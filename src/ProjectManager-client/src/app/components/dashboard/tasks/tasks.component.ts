import { Component, OnInit } from '@angular/core';
import { ProjectTask } from '../models/project-task.model';
import { Person } from '../models/person.model';

import * as moment from 'moment';
import { SnackBarHelper } from 'src/app/helpers/snack-bar.helper';
import { MessageType } from 'src/app/helpers/message-type.enum';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TasksComponent implements OnInit {

  person: Person[] = [
    { id: 1, name: 'Alex Coleman'},
    { id: 2, name: 'Jannet Mendez'},
    { id: 3, name: 'Joe Morgan'},
    { id: 4, name: 'Beatrice Jannus'},
  ];

  tasksList: ProjectTask[] = [
    { id: 1, isConcluded: false, title: "Task 1", priority: 1, conclusionDate: moment('01/12/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttesttesttest", attendant: this.person[1] },
    { id: 2, isConcluded: false, title: "Task 2", priority: 2, conclusionDate: moment('05/12/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttesttesttesttesttesttesttest", attendant: this.person[0] },
    { id: 3, isConcluded: false, title: "Task 3", priority: 3, conclusionDate: moment('15/12/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttesttesttesttesttesttesttesttesttesttest", attendant: this.person[0] },
    { id: 4, isConcluded: false, title: "Task 4", priority: 1, conclusionDate: moment('23/12/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttest", attendant: this.person[2] },
    { id: 5, isConcluded: false, title: "Task 5", priority: 2, conclusionDate: moment('03/01/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttesttest", attendant: this.person[1] },
    { id: 6, isConcluded: false, title: "Task 6", priority: 3, conclusionDate: moment('19/01/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttesttesttesttesttest", attendant: this.person[2] },
    { id: 7, isConcluded: false, title: "Task 7", priority: 1, conclusionDate: moment('12/02/2020', 'DD/MM/YYYY').toDate(), description: "testtesttesttesttesttesttesttesttesttesttesttesttest", attendant: this.person[1] },
  ];

  taskSelected: ProjectTask;

  constructor(private snackHelper: SnackBarHelper) { }  

  ngOnInit(): void {
  }

  selectTask(task: ProjectTask) {
    this.taskSelected = task;
  }  

  toggleTaskStatus(taskStatus: boolean) {
    this.taskSelected.isConcluded = !taskStatus;

    this.tasksList.forEach(el => {
      if (el.id == this.taskSelected.id) el.isConcluded = !taskStatus;
    });
    
    this.snackHelper.showSnackbar(`Tarefa marcada como ${ this.taskSelected.isConcluded ? 'concluída' : 'não concluída' }`, MessageType.OkMessage, 3000);
  }
}