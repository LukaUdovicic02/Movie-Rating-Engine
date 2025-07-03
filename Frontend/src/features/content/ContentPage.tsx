import { useEffect, useState } from "react";
import type { ContentDto } from "../../types/content";
import { getAllContent } from "../../api/contentApi";
import ContentCard from "../../components/ContentCard";

const ContentPage = () => {
  const [content, setContent] = useState<ContentDto[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    getAllContent()
      .then(setContent)
      .catch(console.error)
      .finally(() => setLoading(false));
  }, []);

  return (
    <div>
      <div className="flex justify-center gap-10 mt-8 items-center">
        {loading ? (
          <p>Loading ...</p>
        ) : (
          content.map((item) => <ContentCard key={item.id} content={item} />)
        )}
      </div>
    </div>
  );
};

export default ContentPage;
