import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import {MatDialog} from '@angular/material/dialog';
import { EmployeeDetailsComponent } from '../employee-details/employee-details.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees:Employee[]=new Array<Employee>();
  constructor(private employeeService:EmployeeService,public dialog: MatDialog) 
  { 
    employeeService.GetAll().subscribe(x=>this.employees=x);
  }

  ngOnInit(): void {
  }
  Details(id:number)
  {
    let dialogRef = this.dialog.open(EmployeeDetailsComponent, {
      height: '70%',
      width: '80%',
      disableClose:true,
      closeOnNavigation:true,
      data: {employee:this.employees.find(x=>x.id==id)}
    });
    dialogRef.afterClosed().subscribe(result => { 
      this.employeeService.GetAll().subscribe(x=>this.employees=x);
       
    });
  }
  Delete(id:number)
  {
    if(confirm("Are you sure you want to delete this employee?"))
    {
      this.employeeService.Delete(id).subscribe(data=>this.employeeService.GetAll().subscribe(x=>this.employees=x));
    }
  }
  AddNewEmployee()
  {
    let dialogRef = this.dialog.open(EmployeeDetailsComponent, {
      height: '70%',
      width: '80%',
      disableClose:true,
      closeOnNavigation:true,
      data: {}
    });
    dialogRef.afterClosed().subscribe(result => { 
      this.employeeService.GetAll().subscribe(x=>this.employees=x);
       
    });
  }
}
