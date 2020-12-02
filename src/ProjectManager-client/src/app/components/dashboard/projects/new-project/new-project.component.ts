import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { DateCantBeLowerThanToday } from 'src/app/helpers/dateValidators.validator';
import { MessageType } from 'src/app/helpers/message-type.enum';
import { SnackBarHelper } from 'src/app/helpers/snack-bar.helper';
import { TableComponentComponent } from '../../base-components/table-component/table-component.component';
import { NewProject } from '../../models/new-project.model';
import { Person } from '../../models/person.model';
import { ProjectTask } from '../../models/project-task.model';
import { AddTaskDialogComponent } from '../add-task-dialog/add-task-dialog.component';
import { STEPPER_GLOBAL_OPTIONS } from '@angular/cdk/stepper';

import * as moment from 'moment';
import 'moment/locale/pt-br';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.css'],
  providers: [{
    provide: STEPPER_GLOBAL_OPTIONS, useValue: { displayDefaultIndicatorType: false }
  }]
})
export class NewProjectComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'name'];
  people: Person[] = [
    { id: 1, name: 'Maia'},
    { id: 2, name: 'Asher'},
    { id: 3, name: 'Atticus'},
    { id: 4, name: 'Olivia'},
    { id: 5, name: 'Amelia'},
    { id: 6, name: 'Jack'},
    { id: 7, name: 'Charlotte'},
    { id: 8, name: 'Theodore'},
    { id: 9, name: 'Isla'},
    { id: 10, name: 'Oliver'}    
  ];  

  constructor(private dialog: MatDialog,
              private snackHelper: SnackBarHelper) { 
    this.moment.locale('pt-br');              
  }

  @ViewChild('stepper') private stepper: MatStepper;
  @ViewChild('attendantsTable') private attendantsTable: TableComponentComponent;

  moment: any = moment;

  projectDataForm: FormGroup;

  projectData: NewProject;

  selectedAttendants: Person[];
  newTask: ProjectTask;
  projectTasks: ProjectTask[] = [];

  disablePrevSteps: boolean = false;

  ngAfterViewInit(): void { }

  ngOnInit(): void { 
    this.projectDataForm = new FormGroup({
      projectTitle: new FormControl('', [Validators.required, Validators.maxLength(255)]),
      startDate: new FormControl('', [Validators.required, DateCantBeLowerThanToday]),
      endDate: new FormControl('', [Validators.required, DateCantBeLowerThanToday]),
      description: new FormControl('', [Validators.required])
    });
  }

  saveProjectData() {
    this.projectData = Object.assign({}, this.projectData, this.projectDataForm.value);   
  }

  getAttendants() {
    this.selectedAttendants = this.attendantsTable.selection.selected;    
    setTimeout(() => {
      this.stepper.next();
    }, 1);
  }

  openNewTaskDialog() {
    this.newTask = new ProjectTask(this.setTaskId())

    let dialogRef = this.dialog.open(AddTaskDialogComponent, {
      hasBackdrop: true,
      height: '540px',
      width: '700px',
      data: {
        newTask: this.newTask,
        selectedAttendants: this.selectedAttendants,
        projectConclusionDate: this.projectDataForm.get('endDate').value
      }
    });

    dialogRef.afterClosed().subscribe((task: ProjectTask) => {
      if (task != null) {
        this.projectTasks.push(task);        
        this.snackHelper.showSnackbar("Tarefa incluída", MessageType.OkMessage, 2000);
      }
    });    
  }

  removeTask(task: ProjectTask){
    this.projectTasks = this.projectTasks.filter(p => p !== task);
    this.snackHelper.showSnackbar("Tarefa Removida", MessageType.OkMessage, 2000);
  }

  editTask(task: ProjectTask) {
    let editDialogRef = this.dialog.open(AddTaskDialogComponent, {
      hasBackdrop: true,
      height: '540px',
      width: '700px',
      data: {
        taskToEdit: task,
        selectedAttendants: this.selectedAttendants,
        projectConclusionDate: this.projectDataForm.get('endDate').value
      }
    });

    editDialogRef.afterClosed().subscribe((task: ProjectTask) => {
      if (task != null) {
        this.projectTasks.forEach((el, i) => {
          if (el.id == task.id) {
            this.projectTasks[i] = task;
          }
        });
        
        this.snackHelper.showSnackbar("Tarefa editada", MessageType.OkMessage, 2000);
      }
    });
  }

  setTaskId() {
    if (this.projectTasks.length > 0) {
      return this.projectTasks.length + 1;
    } else {
      return 1;
    }
  }

  isStepComplete(step: number) {
    switch (step) {
      case 1:
        return this.projectDataForm.valid;        
        break;
      case 2:
        return (this.selectedAttendants != null && this.selectedAttendants.length > 0)
        break;
      case 3:
        return (this.projectTasks != null && this.projectTasks.length > 0)
        break;          
    }
  }  

  createProject(){
    this.projectData.tasks = this.projectTasks;
    this.projectData.attendants = this.selectedAttendants;

    this.disablePrevSteps = true;

    setTimeout(() => {
      this.stepper.next();
    }, 1);
  }

  hasError(controlName: string, errorName: string){
    return this.projectDataForm.controls[controlName].hasError(errorName);
  }
}