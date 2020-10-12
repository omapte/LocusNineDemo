import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import * as _ from 'lodash';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { UserGridComponent } from './user-grid/user-grid.component';
import { UserService } from './user.service';
import { AddOrUpdateUserComponent } from './add-or-update-user/add-or-update-user.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    UserGridComponent,
    AddOrUpdateUserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
