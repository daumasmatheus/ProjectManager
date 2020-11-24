import { AfterViewInit, Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { SnackBarHelper } from 'src/app/helpers/snack-bar.helper';
import { AddTaskDialogComponent } from '../add-task-dialog/add-task-dialog.component';

export interface Person {
  id: number,
  name: string
}

const NAMES: string[] = [
  'Maia', 'Asher', 'Olivia', 'Atticus', 'Amelia', 'Jack', 'Charlotte', 'Theodore', 'Isla', 'Oliver',
  'Isabella', 'Jasper', 'Cora', 'Levi', 'Violet', 'Arthur', 'Mia', 'Thomas', 'Elizabeth'
];

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.css']
})
export class NewProjectComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['id', 'name'];
  people: Person[] = Array.from({length: 100}, (_, k) => createNewPerson(k+1));

  constructor(private dialog: MatDialog,
              private snackHelper: SnackBarHelper) { }

  ngAfterViewInit(): void { }

  ngOnInit(): void { }

  openNewTaskDialog() {
    this.dialog.open(AddTaskDialogComponent, {
      hasBackdrop: true,
      height: '540px',
      width: '700px'
    })
  }
}

function createNewPerson(id: number): Person {
  const name = NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
               NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

  return {
    id: id,
    name: name    
  };
}