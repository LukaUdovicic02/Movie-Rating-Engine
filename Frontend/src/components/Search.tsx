import { useState } from "react";

type Props = {
  onSearchChange: (title?: string, releaseDate?: string) => void;
};

function Search({ onSearchChange }: Props) {
  const [_, setValue] = useState<string>("");

  const isDateFormat = (input: string): boolean => {
    return /^\d{4}-\d{2}-\d{2}$/.test(input);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const val = e.target.value;
    setValue(val);

    if (isDateFormat(val)) {
      onSearchChange(undefined, val);
    } else {
      onSearchChange(val);
    }
  };

  return (
    <div>
      <div className="flex justify-center mt-8">
        <div>
          <input
            onChange={handleChange}
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
