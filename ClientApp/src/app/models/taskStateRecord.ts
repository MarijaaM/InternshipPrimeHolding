import { TaskState } from "./taskState";

export class TaskStateRecord
{
    state:TaskState=TaskState.ToDo;
    timestamp:Date=new Date();
}