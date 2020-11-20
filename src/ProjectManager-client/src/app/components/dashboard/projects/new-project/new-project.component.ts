import { AfterViewInit, Component, OnInit } from '@angular/core';

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

  constructor() { }

  ngAfterViewInit(): void { }

  ngOnInit(): void { }
}

function createNewPerson(id: number): Person {
  const name = NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
               NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

  return {
    id: id,
    name: name    
  };
}