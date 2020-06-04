import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/Todo';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.css']
})
export class TodosComponent implements OnInit {

  todos:Todo[]
  
  constructor(private todoService: TodoService) { 
  }

  ngOnInit() {
    this.todoService.getTodos().subscribe( todos => {
      this.todos = todos;
    });
  }

  deleteTodo(todoToDelete:Todo) : void {
    console.log(todoToDelete);
     this.todos = this.todos.filter( t => t.id !== todoToDelete.id);
     //delete from backend
     this.todoService.deleteTodo(todoToDelete).subscribe();
  }

  addTodoAndSend(todoToAdd:Todo){
    this.todoService.addTodo(todoToAdd).subscribe( todo => {
      this.todos.push(todo);
    })
    
  }

}
