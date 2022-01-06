import React from "react";
import TodoItem from "./TodoItem";


export default function TodoList(props) {
  const parsedTodos = Array.isArray(todos) 
    && todos.map(todo => <TodoItem todo={todo} />);
  return (
    <>
      {parsedTodos}
    </>
  );
}