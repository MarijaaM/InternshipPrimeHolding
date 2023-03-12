import { WorkTask } from "./workTask";

export class Employee
{
    id:number=0;
    fullName:string="";
    email:string="";
    phoneNumber:string="";
    dateOfBirth:Date=new Date();
    monthlySalary:number=0;
    workTasks:Array<WorkTask>=new Array<WorkTask>();
}
 