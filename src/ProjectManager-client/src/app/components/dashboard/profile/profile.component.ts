import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
              public dialogRef: MatDialogRef<ProfileComponent>) { }

  userName: string;  
  selectedPic: any;  

  ngOnInit(): void {
    this.userName = this.data.userName;
  }

  closeDialog() {
    this.dialogRef.close();
  }

  selectUserPic(event) {
    console.log(event);
  }
}