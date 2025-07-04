import React from "react";

type Props = {};

function Search({}: Props) {
  return (
    <div>
      <div className="flex justify-center mt-8">
        <div>
          <input
            className="bg-gray-200 sm:w-72 lg:w-96 rounded-md px-4 p-2 border
             border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-300
              focus:border-transparent transition duration-500 shadow-sm"
            type="text"
            placeholder="Search movies or shows ..."
          />
        </div>
      </div>
    </div>
  );
}

export default Search;
