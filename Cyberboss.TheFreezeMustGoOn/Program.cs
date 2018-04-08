using Octokit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Cyberboss.TheFreezeMustGoOn
{
	static class Program
	{
		static async Task Main(string[] args)
		{
			var ghc = new GitHubClient(new ProductHeaderValue(Assembly.GetExecutingAssembly().GetName().Name))
			{
				Credentials = new Credentials(args.First())
			};
			var pr = await ghc.PullRequest.Get("tgstation", "tgstation", 36960).ConfigureAwait(false);
			if (pr.State.Value != ItemState.Open)
				return;
			var timeSinceCreated = DateTimeOffset.Now - pr.CreatedAt;
			var waitFor = new TimeSpan(7, 0, 0, 0) - timeSinceCreated;
			await Task.Delay(waitFor).ConfigureAwait(false);
			await ghc.PullRequest.Update(pr.Base.Repository.Id, pr.Number, new PullRequestUpdate { State = ItemState.Closed }).ConfigureAwait(false);
		}
	}
}
