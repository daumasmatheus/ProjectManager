import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DateCantBeLowerThanToday, TaskConclusionDateCantBeHigherThanProjectConclusionDate } from 'src/app/helpers/dateValidators.validator';
import { Person } from '../../models/person.model';
import { ProjectTask } from '../../models/project-task.model';

@Component({
  selector: 'app-add-task-dialog',
  templateUrl: './add-task-dialog.component.html',
  styleUrls: ['./add-task-dialog.component.css']
})
export class AddTaskDialogComponent implements OnInit {
  attendants: Person[];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public dialogRef: MatDialogRef<AddTaskDialogComponent>) { }  

  taskForm: FormGroup;
  taskData: ProjectTask;
  selectedAttendant: Person;
  projectConclusionDate: Date;

  ngOnInit(): void {
    this.projectConclusionDate = this.data?.projectConclusionDate;

    this.taskForm = new FormGroup({
      title: new FormControl('', [Validators.required]),
      priority: new FormControl('', [Validators.required]),
      conclusionDate: new FormControl('', [Validators.required, 
                                           DateCantBeLowerThanToday, 
                                           TaskConclusionDateCantBeHigherThanProjectConclusionDate(this.projectConclusionDate)]),
      description: new FormControl('', [Validators.required]),
      attendant: new FormControl('', [Validators.required])
    });

    if (this.data != null && this.data.newTask){
      this.taskData = new ProjectTask(this.data.newTask.id);
      this.attendants = this.data.selectedAttendants;      
    }
    if (this.data != null && this.data.taskToEdit){
      this.taskForm.patchValue(this.data.taskToEdit);
      this.selectedAttendant = this.data.taskToEdit.attendant;      

      this.attendants = this.data.selectedAttendants;
    }    
  }

  saveTaskData() {
    this.taskData = Object.assign({}, this.taskData, this.taskForm.value);
    if (this.taskData.id == null)
      this.taskData.id = this.data.taskToEdit.id;

    this.dialogRef.close(this.taskData);
  }  

  closeDialog() {
    this.dialogRef.close();
  }
  
  compareSelected(option, value) {
    return option.id == value.id;
  }

  hasError(controlName: string, errorName: string) {
    return this.taskForm.controls[controlName].hasError(errorName);
  }
}