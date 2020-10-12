import { Component, EventEmitter, Input, Output, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-or-update-user',
  templateUrl: './add-or-update-user.component.html',
  styleUrls: ['./add-or-update-user.component.css']
})
export class AddOrUpdateUserComponent implements OnInit {
  

  @Output() userCreated = new EventEmitter<any>();
  @Input() userInfo: any;

  public buttonText = 'Add User';

  constructor() { 
    this.clearInfo();
    console.log(this.userInfo.name);
  }

  ngOnInit(): void {
  }

  private clearInfo = function() {
    // Create an empty 
    this.userInfo = {
      name: '',
      role: '',
      email: '',
      status: ''
    };
  };

  public addOrUpdateUserRecord = function(event) {
    this.userCreated.emit(this.userInfo);
    
    this.clearInfo();
  };
}
