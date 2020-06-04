import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http'
import { Todo } from '../models/Todo';
import { Observable } from 'rxjs';


const httpOptions = {
  headers : new HttpHeaders({
    'Content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  
  todosUrl:string = "https://jsonplaceholder.typicode.com/todos";
  limitUrl:string = "?_limit=5";
  
  constructor(private http:HttpClient) { }

  getTodos():Observable<Todo[]>{
    return this.http.get<Todo[]>(this.todosUrl+this.limitUrl);
  }
  updateTodo(todo:Todo):Observable<any>{
    return this.http.put(this.todosUrl+`/${todo.id}`, todo, httpOptions);
  }

  deleteTodo(todo:Todo):Observable<Todo>{
    return this.http.delete<Todo>(this.todosUrl+`/${todo.id}`);

  }

  addTodo(todo:Todo):Observable<Todo>{
    return this.http.post<Todo>(this.todosUrl, todo, httpOptions);
  }

  getTodo(id:string):Observable<Todo> {
    return this.http.get<Todo>(`${this.todosUrl}/${id}`);
  }
}
