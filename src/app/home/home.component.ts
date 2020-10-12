import { Component, OnInit } from '@angular/core';

import { UserService } from '../user.service'
import * as _ from 'lodash';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public userData: Array<any>;
  public currentUser: any;
 
  constructor(private userService: UserService) { 
    userService.get().subscribe((data: any) => this.userData = data);
    this.currentUser = this.setInitialValuesForUserData(); 
    //console.log(this.userData);
  }

  ngOnInit(): void {
    
  }

  public editClicked = function(record) {
    this.currentUser = record;
  };

  public newClicked = function() {
    this.currentUser = this.setInitialValuesForUserData(); 
  };

  public deleteClicked(record) {
    const deleteIndex = _.findIndex(this.userData, {id: record.id});
    this.userService.remove(record).subscribe(
      result => this.userData.splice(deleteIndex, 1)
    );
  }

  private setInitialValuesForUserData () {
    return {
      name: '',
      email: '',
      role: '',
      status: 'Active',
      contactNumber:''
    }
  }

  public createOrUpdateUser = function(user: any) {
    // if User is present in UserData, we can assume this is an update
    // otherwise it is adding a new element
    let UserWithId;
    UserWithId = _.find(this.userData, (el => el.id === user.id));

    if (UserWithId) {
      const updateIndex = _.findIndex(this.userData, {id: UserWithId.id});
      this.userService.update(user).subscribe(
        UserRecord =>  this.userData.splice(updateIndex, 1, user)
      );
    } else {
      this.userService.add(user).subscribe(
        UserRecord => this.userData.push(user)        
      );

      
      this.userService.get().subscribe((data: any) => this.userData = data);
    }

    this.currentUser = this.setInitialValuesForUserData();
  };

}
