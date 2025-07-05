import type { ContentType } from "../types/content";

type Props = {
  onTypeChange: (type: ContentType) => void;
};

const ToggleSwitch = ({ onTypeChange }: Props) => {
  return (
    <div>
      <div className="flex justify-center gap-4 mt-8">
        <button
          onClick={() => onTypeChange("Movie")}
          className="bg-gray-300 px-4 py-1.5 rounded-md
         shadow-lg hover:bg-gray-200 border border-gray-100 transition duration-500 w-24"
        >
          Movie
        </button>

        <button
          onClick={() => onTypeChange("TVShow")}
          className="bg-gray-300 px-4 py-1.5 rounded-md
         shadow-lg hover:bg-gray-200 border border-gray-100 transition duration-500 w-24"
        >
          TV Show
        </button>
      </div>
    </div>
  );
};

export default ToggleSwitch;
