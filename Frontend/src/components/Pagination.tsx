import React from "react";

type Props = {};

function Pagination({}: Props) {
  return (
    <div className="flex justify-center mt-8">
      <button
        className="bg-gray-300 px-4 py-1.5 rounded-md
         shadow-lg hover:bg-gray-200 border border-gray-100 transition duration-500"
      >
        View More Results
      </button>
    </div>
  );
}

export default Pagination;
