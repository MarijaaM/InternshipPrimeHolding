import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeTaskCount } from 'src/app/models/employeeTaskCount';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-best-employees',
  templateUrl: './best-employees.component.html',
  styleUrls: ['./best-employees.component.css']
})
export class BestEmployeesComponent implements OnInit {
  employees:Array<EmployeeTaskCount>=new Array<EmployeeTaskCount>();
  constructor(private employeeService:EmployeeService) {
      employeeService.GetBest().subscribe(x=>this.employees=x);
  }

  ngOnInit(): void {
  }

}
