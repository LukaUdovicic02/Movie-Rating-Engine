import { useState } from "react";

type Props = {
  onSearchChange: (
    title?: string,
    releaseDate?: string,
    minRating?: number
  ) => void;
};

function Search({ onSearchChange }: Props) {
  const [value, setValue] = useState<string>("");

  const parseSearch = (input: string) => {
    let title: string | undefined;
    let releaseDate: string | undefined;
    let minRating: number | undefined;

    const lower = input.toLowerCase();

    
    const exactRating = lower.match(/(\d+)\s*stars?/);
    const atLeastRating = lower.match(/at least (\d+)\s*stars?/);
    if (atLeastRating) {
      minRating = parseInt(atLeastRating[1]);
    } else if (exactRating) {
      minRating = parseInt(exactRating[1]);
    }

    
    const afterYear = lower.match(/after (\d{4})/);
    const olderThan = lower.match(/older than (\d+)\s*years?/);
    if (afterYear) {
      releaseDate = `${afterYear[1]}-01-01`;
    } else if (olderThan) {
      const years = parseInt(olderThan[1]);
      const pastYear = new Date().getFullYear() - years;
      releaseDate = `${pastYear}-01-01`;
    }

    
    if (!minRating && !releaseDate) {
      title = input.length >= 2 ? input : undefined;
    }

    onSearchChange(title, releaseDate, minRating);
  };

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const val = e.target.value;
    setValue(val);

    if (val.length >= 2) {
      parseSearch(val);
    } else {
      onSearchChange(); 
    }
  };

  return (
    <div className="flex justify-center mt-8">
      <input
        onChange={handleChange}
        value={value}
        className="bg-gray-200 sm:w-72 lg:w-96 rounded-md px-4 p-2 border
         border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-300
         focus:border-transparent transition duration-500 shadow-sm"
        type="text"
        placeholder='Search (e.g. "5 stars", "after 2020")'
      />
    </div>
  );
}

export default Search;
