import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {
  employee:Employee=new Employee();
  formEmployee:FormGroup=new FormGroup({}); 
  editForm:boolean=false;
  constructor(private employeeService:EmployeeService, public dialogRef: MatDialogRef<EmployeeDetailsComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) public input: any) 
    {
      this.employee=input['employee'];
      
      this.editForm=this.employee!=null;  
    }

  ngOnInit(): void {
    this.formEmployee=new FormGroup({
      'email':new FormControl(this.employee?.email, Validators.required),
      'fullName':new FormControl(this.employee?.fullName, Validators.required),
      'phoneNumber':new FormControl(this.employee?.phoneNumber, Validators.required),
      'dateOfBirth':new FormControl(this.employee?.dateOfBirth.toString().substring(0,10), Validators.required),
      'monthlySalary':new FormControl(this.employee?.monthlySalary, Validators.required)
  }); 
  }
  Close()
  { 
    this.dialogRef.close();
  }
  SubmitForm()
  {
    if(this.formEmployee.valid)
    {

      var employee=new Employee();
      
      employee.email=this.formEmployee.value['email'];
      employee.fullName=this.formEmployee.value['fullName'];
      employee.dateOfBirth=this.formEmployee.value['dateOfBirth'];
      employee.phoneNumber=this.formEmployee.value['phoneNumber'];
      employee.monthlySalary=this.formEmployee.value['monthlySalary'];
      if(this.editForm)
      {
        employee.id=this.employee.id;
        this.employeeService.Edit(employee).subscribe(data=>alert("Successfully updated"));
      }
      else
      {
        this.employeeService.Add(employee).subscribe(data=>this.dialogRef.close());
      }
    }
    else
    {
      alert("Invalid input");
    }
  }
  DeleteTask(id:number)
  {
     
  }
}
