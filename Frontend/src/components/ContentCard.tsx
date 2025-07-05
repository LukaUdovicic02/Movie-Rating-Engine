import type { ContentDto } from "../types/content";

type Props = {
  content: ContentDto;
};

const ContentCard = ({ content }: Props) => {
  return (
    <div className="border rounded-xl shadow p-4 bg-gray-200 lg:w-[300px] sm:w-[350px] xs:w-[95%] ">
      <img
        src={content.imageURL}
        alt={content.title}
        className="h-72 w-52  object-cover rounded-lg"
      />
      <h2 className="font-bold mt-2 text-xl">{content.title}</h2>
      <p className="mt-2 text-md">{content.description}</p>
      <p className="mt-1 text-md">{content.type}</p>
      <p className="mt-1 text-md">
        {new Date(content.releaseDate).toLocaleDateString()}
      </p>
    </div>
  );
};

export default ContentCard;
