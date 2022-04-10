import * as signalR from '@microsoft/signalr';

export class ChatSignalrClient {
  private connection?: signalR.HubConnection;

  public messageReceived: (data: any) => void = () => {};
  private host: string = '';

  constructor(host: string) {
    this.host = host;
    this.connection = this.getClient();
  }

  public start() {
    this.connection = this.getClient();
    this.connection.on('Message', this.messageReceived);

    return this.connection.start();
  }

  public send(message: any) {
    return this.connection?.invoke('Send', message);
  }

  public stop() {
    return this.connection!.stop();
  }

  private getClient() {
    return new signalR.HubConnectionBuilder().withUrl(this.host).build();
  }
}
