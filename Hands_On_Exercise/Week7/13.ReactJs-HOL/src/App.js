import React, { useState } from "react";
import BookDetails from "./components/BookDetails";
import BlogDetails from "./components/BlogDetails";
import CourseDetails from "./components/CourseDetails";

function App() {
  const [view, setView] = useState("book"); // can be: book, blog, course
  const [showCourses, setShowCourses] = useState(true); // for && rendering
  const books = [
    { title: "Clean Code", author: "Robert C. Martin" },
    { title: "You Don't Know JS", author: "Kyle Simpson" },
  ];
  const blogs = [
    { title: "React Basics", category: "React" },
    { title: "Understanding State", category: "React" },
  ];
  const courses = [
    { name: "React Mastery", price: 5999 },
    { name: "JS Fundamentals", price: 3999 },
  ];
  // Element variable approach
  let content;
  if (view === "book") {
    content = <BookDetails books={books} />;
  } else if (view === "blog") {
    content = <BlogDetails blogs={blogs} />;
  } else {
    content = <CourseDetails courses={courses} />;
  }
  return (
    <div style={{ padding: "20px", fontFamily: "Arial" }}>
      <h1>🧑‍💻 Blogger App</h1>
      {/* Conditional Rendering with Ternary */}
      <div>
        <button onClick={() => setView("book")}>Show Books</button>
        <button onClick={() => setView("blog")}>Show Blogs</button>
        <button onClick={() => setView("course")}>Show Courses</button>
      </div>
      <hr />
      {/* Element Variable Rendering */}
      {content}
      {/* && Rendering */}
      <hr />
      <button onClick={() => setShowCourses(!showCourses)}>
        Toggle Courses Section (&& example)
      </button>
      {showCourses && <CourseDetails courses={courses} />}
      {/* Prevent Component Rendering using conditional return */}
      <hr />
      {view === "none" ? null : <p>Currently viewing: {view}</p>}
    </div>
  );
}
export default App;
